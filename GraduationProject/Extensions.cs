using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GraduationProject.DatabaseContext;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace GraduationProject
{
    public static class Extensions
    {

        public static void UpdateDatabaseAutomaic(this IApplicationBuilder app)
        {
            using (var scope= app.ApplicationServices.GetService<IServiceScopeFactory>().CreateScope())
            {
                scope.ServiceProvider.GetService<GraduationProjectContext>().Database.Migrate();
            }
        }
    }
}
