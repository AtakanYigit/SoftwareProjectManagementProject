﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entity.Concrete;

namespace DataAccess.Concrete
{
    public class UserMedicationDal : EfEntityRepositoryBase<UserMedications, BaseDbContext>, IUserMedicationDal
    {
        public UserMedicationDal(BaseDbContext context) : base(context)
        {
        }
    }
}
