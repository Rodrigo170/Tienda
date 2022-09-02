﻿using Core.Entities;
using Core.Interfaces;
using Infrastructure.Data;
using Infrastructure.UnitOfWork;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
    public class ProductosController : BaseApiController
    {
        //context ES PARA ACCEDER A LOS PRODUCTOS
        private readonly IUnitOfWork _unitOfWork;

        public ProductosController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        //MÉTODO PARA EL LISTADO DE PRODUCTOS
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]

        public async Task<ActionResult<IEnumerable<Producto>>> Get()
        {
            var productos = await _unitOfWork.Productos
                                    .GetAllAsync();

            return Ok(productos);
        }


        //MÉTODO PARA EL LISTADO DE PRODUCTOS con ID
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]

        public async Task<ActionResult<IEnumerable<Producto>>> Get(int id)
        {
            var productos = await _unitOfWork.Productos.GetByIdAsync(id);

            return Ok(productos);
        }

        //AÑADIR PRODUCTOS
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<Producto>> Post(Producto producto)
        {
            _unitOfWork.Productos.Add(producto);
            _unitOfWork.Save();
            if(producto == null)
            {
                return BadRequest();
            }
            return CreatedAtAction(nameof(Post), new { id = producto.Id }, producto);
        }

        //PUT: api/Productos/4
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]

        public async Task<ActionResult<Producto>> Put(int id, [FromBody]Producto producto)
        {
            if (producto == null)
                return NotFound();

            _unitOfWork.Productos.Update(producto);
            _unitOfWork.Save();

            return producto;
        }

        //ELIMINAR UN PRODUCTO

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]

        public async Task<IActionResult> Delete(int id)
        {
            var producto = await _unitOfWork.Productos.GetByIdAsync(id);
            if (producto == null)
                return NotFound();

            _unitOfWork.Productos.Remove(producto);
            _unitOfWork.Save();

            return NoContent();
        }


    }
}
