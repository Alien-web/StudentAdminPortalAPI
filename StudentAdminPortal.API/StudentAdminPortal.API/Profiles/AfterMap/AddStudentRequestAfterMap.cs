using AutoMapper;
using StudentAdminPortal.API.DataModels;
using StudentAdminPortal.API.DomainModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentAdminPortal.API.Profiles.AfterMap
{
    public class AddStudentRequestAfterMap : IMappingAction<AddStudentRequest, DataModels.Students>
    {
        public void Process(AddStudentRequest source, Students destination, ResolutionContext context)
        {
            destination.id = Guid.NewGuid();
            destination.Address = new DataModels.Address()
            {
                id = Guid.NewGuid(),
                PhysicalAddress = source.PhysicalAddress,
                PostalAddress = source.PostalAddress
            };
        }
    }
}
