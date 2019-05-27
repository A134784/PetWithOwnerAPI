using PetWithOwnerApplication.Entity;
using System.Collections.Generic;

namespace PetWithOwnerApplication.Repository
{
    public interface IPetRepository
    {
       IEnumerable<PetResultViewModel> GetPetNamesAccordingToGender();
    }
}
