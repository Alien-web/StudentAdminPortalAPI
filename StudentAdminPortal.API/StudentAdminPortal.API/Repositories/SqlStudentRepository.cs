using Microsoft.EntityFrameworkCore;
using StudentAdminPortal.API.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentAdminPortal.API.Repositories
{
    public class SqlStudentRepository : IStudentRepository
    {
        private readonly StudentAdminContext context;

        public SqlStudentRepository(StudentAdminContext context)
        {
            this.context = context;
        }

        public async Task<Students> AddStudent(Students studentToAdd)
        {
            var student = await context.Student.AddAsync(studentToAdd);
            await context.SaveChangesAsync();
            return student.Entity;
        }

        public async Task<Students> DeleteStudent(Guid studentId)
        {
            var existingStudent = await GetStudentAsync(studentId);
            if (existingStudent != null)
            {
                context.Student.Remove(existingStudent);
                await context.SaveChangesAsync();
                return existingStudent;
            }
            return null;
        }
        public async Task<bool> Exists(Guid studentId)
        {
            return await context.Student.AnyAsync(x => x.id == studentId);
        }

        public async Task<List<Gender>> GetGenderAsync()
        {
            return await context.Gender.ToListAsync();
        }

        public async Task<Students> GetStudentAsync(Guid studentId)
        {
            return await context.Student.Include(nameof(Gender)).Include(nameof(Address)).FirstOrDefaultAsync(x=>
            x.id== studentId);
        }

        public async Task<List<Students>> GetStudentsAsync()
        {
            return await context.Student.Include(nameof(Gender)).Include(nameof(Address)).ToListAsync();
        }

        public async Task<Students> UpdateStudent(Guid studentId, Students studentToUpdate)
        {
            var existingStudent = await GetStudentAsync(studentId);
            if (existingStudent != null)
            {
                existingStudent.FirstName = studentToUpdate.FirstName;
                existingStudent.LastName = studentToUpdate.LastName;
                existingStudent.Email = studentToUpdate.Email;
                existingStudent.Mobile = studentToUpdate.Mobile;
                existingStudent.DateOfBirth = studentToUpdate.DateOfBirth;
                //existingStudent.Address.PhysicalAddress = studentToUpdate.Address.PhysicalAddress;
                //existingStudent.Address.PostalAddress = studentToUpdate.Address.PostalAddress;
                existingStudent.GenderId = studentToUpdate.GenderId;

                await context.SaveChangesAsync();
                return existingStudent;
            }
            return null;
        }
    }
}
