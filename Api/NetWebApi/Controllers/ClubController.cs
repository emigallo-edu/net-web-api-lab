﻿using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Model.Entities;
using Model.Repositories;
using NetWebApi.Model;
using Security;

namespace NetWebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]

    public class ClubController : ControllerBase
    {
        private readonly IClubRepository _repository;
        private readonly IMapper _mapper;

        public ClubController(IClubRepository repository, IMapper mapper)
        {
            this._repository = repository;
            this._mapper = mapper;
        }

        [HttpPost]
        public async Task<IActionResult> Create(ClubDTO club)
        {
            await this._repository.InsertAsync(this._mapper.Map<Club>(club));
            return Ok();
        }


        [HttpGet("id/{id}")]
        public async Task<IActionResult> Get([FromRoute] int id)
        {
            Club result = await this._repository.GetByIdAsync(id);
            return Ok(result);
        }

        [HttpGet("all")]
        //[Authorize(Roles = Roles.USER)]
        public async Task<IActionResult> GetAll()
        {
            var result = await this._repository.GetAllAsync();

            foreach (var item in result.Where(x => x.Stadium != null))
            {
                item.Stadium.Club = null;
            }

            return Ok(result);
        }

        [HttpGet("short")]
        public async Task<IActionResult> GetAllShort()
        {
            var result = await this._repository.GetAllShortAsync();
            return Ok(result);
        }

        [HttpPatch("name")]
        public async Task<IActionResult> ChangeName(ChangeClubNameDTO dto)
        {
            await this._repository.ChangeName(dto.Id, dto.Name);
            return Ok("El registro se modifico correctamente");
        }

        [HttpPut()]
        public async Task<IActionResult> Update(ClubDTO club)
        {
            await this._repository.UpdateAsync(this._mapper.Map<Club>(club));
            return Ok();
        }

        [HttpPut("withStadium")]
        public async Task<IActionResult> UpdateWithStadium(List<Club> clubs)
        {
            await this._repository.UpdateWithStadiumAsync(clubs);
            return Ok();
        }
    }

    public static class Claims
    {
        public const string CREATE_INVOICE = "CrearFactura";
        public const string GET_INVOICES = "ObtenerFacturas";
    }
}