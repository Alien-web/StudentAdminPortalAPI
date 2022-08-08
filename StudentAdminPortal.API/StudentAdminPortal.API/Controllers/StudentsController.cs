using AutoMapper;
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
    public class StudentsController : Controller
    {
       
        private readonly IStudentRepository studentRepository;
        private readonly IMapper mapper;

        public StudentsController(IStudentRepository studentRepository,IMapper mapper)
        {
            this.studentRepository = studentRepository;
            this.mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllStudentsAsync()
        {
            var students = await studentRepository.GetStudentsAsync();
            return Ok(mapper.Map<List<Student>>(students));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetStudentAsync([FromRoute] Guid id)
        {
            var student = await studentRepository.GetStudentAsync(id);
            if (student==null)
            {
                return NotFound();
            }
            return Ok(mapper.Map<Student>(student));
        }

        [HttpPost("{id}")]
        public async Task<IActionResult> UpdateStudentAsync([FromRoute] Guid Id,[FromBody] UpdateStudentRequest request )
        {
            if(await studentRepository.Exists(Id))
            {
                var updatedStudent=await studentRepository.UpdateStudent(Id,mapper.Map<DataModels.Students>(request));
                if (updatedStudent != null)
                {
                    return Ok(mapper.Map<Student>(updatedStudent));
                }
                return NotFound();
            }
            else
            {
                return NotFound();
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteStudentAsync([FromRoute] Guid Id)
        {
            if (await studentRepository.Exists(Id))
            {
                var deletedStudent = await studentRepository.DeleteStudent(Id);
                return Ok(mapper.Map<Student>(deletedStudent));
            }
            else
            {
                return NotFound();
            }
        }
    }


}
