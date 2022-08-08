using StudentAdminPortal.API.DataModels;
using StudentAdminPortal.API.DomainModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentAdminPortal.API.Repositories
{
   public interface IStudentRepository
    {
        Task<List<Students>> GetStudentsAsync();
        Task<List<DataModels.Gender>> GetGenderAsync();
        Task<Students> GetStudentAsync(Guid studentId);
        Task<Boolean> Exists(Guid studentId);
        Task<Students> UpdateStudent(Guid studentId, Students studentToUpdate);
        Task<Students> DeleteStudent(Guid studentId);
        Task<Students> AddStudent(Students studentToAdd);

    }
}
