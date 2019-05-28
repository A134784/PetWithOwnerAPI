
namespace PetWithOwnerApplication.Repository
{
    using PetWithOwnerApplication.Entity;
    using System.Collections.Generic;
    public interface IPetRepository
    {
       IEnumerable<PetResultViewModel> GetPetNamesAccordingToGender();
    }
}
