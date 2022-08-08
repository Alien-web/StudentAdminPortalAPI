﻿using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using StudentAdminPortal.API.DomainModels;
using StudentAdminPortal.API.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentAdminPortal.API.Controllers
{

    [ApiController]
    [Route("[controller]")]
    public class GenderController : Controller
    {
        private readonly IStudentRepository studentRepository;
        private readonly IMapper mapper;

        public GenderController(IStudentRepository studentRepository, IMapper mapper)
        {
            this.studentRepository = studentRepository;
            this.mapper = mapper;
        }
        [HttpGet]
        public async Task<IActionResult> GetGenderAsync()
        {
            var genderList = await studentRepository.GetGenderAsync();
            if (genderList == null || !genderList.Any())
            {
                return NotFound();
            }
            return Ok(mapper.Map<List<Gender>>(genderList));
        }
    }
}
