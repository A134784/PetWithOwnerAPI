using PetWithOwnerApplication.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetWithOwnerApplication.Service
{
    public interface IGetPetServiceData
    {
        IEnumerable<PetOwnerModel> GetPetDataFromService();
    }
}
