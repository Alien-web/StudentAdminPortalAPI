using Microsoft.AspNetCore.Http;
using StudentAdminPortal.API.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentAdminPortal.API.Repositories
{
    public interface IImageRepository
    {
        Task<String> UploadImage(IFormFile file, String fileName);
    }
}
