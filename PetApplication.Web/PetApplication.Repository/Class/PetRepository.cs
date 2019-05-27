namespace PetWithOwnerApplication.Repository.Class
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Entity;
    using Service;
    using Utility;

    public class PetRepository : IPetRepository
    {
        private readonly IGetPetServiceData _petDataService;

        public PetRepository(IGetPetServiceData petDataService)
        {
            this._petDataService = petDataService;
        }

        public IEnumerable<PetResultViewModel> GetPetNamesAccordingToGender()
        {
            try
            {
                IEnumerable<PetOwnerModel> petOwnerResult = this._petDataService.GetPetDataFromService().ToList();
                if (petOwnerResult.Any())
                {
                    var result = petOwnerResult
                     .GroupBy(o => o.Gender)
                     .Select(r => new PetResultViewModel
                     {
                         Gender = r.Key,
                         PetNames = r
                         .SelectManyIgnoringNull(co => co.Pets)
                         .Where(c => c.Type == Constant.CatKey)
                         .Select(c => c.Name)
                         .Distinct()
                         .OrderBy(pet => pet).ToList()
                     }).ToList();
                    return result;
                }
                return null;
            }
            catch (Exception ex)
            {
                Log.LogError(ex);
                throw;
            }
        }

    }
}
