using GraduationProject.GraduationProjectLogic;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GraduationProject.DatabaseContext
{
    public class GraduationProjectContext :  DbContext
    {


        public GraduationProjectContext(DbContextOptions<GraduationProjectContext> options) :base(options)
        {

        }


        public DbSet<Users> Users { get; set; }
    }
}
