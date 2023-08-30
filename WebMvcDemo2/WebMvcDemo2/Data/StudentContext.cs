using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WebMvcDemo2.Models;

namespace WebMvcDemo2.Data
{
    public class StudentContext : DbContext
    {
        public StudentContext (DbContextOptions<StudentContext> options)
            : base(options)
        {
        }

        public DbSet<WebMvcDemo2.Models.Student> Student { get; set; }
        public DbSet<WebMvcDemo2.Models.Library> Library { get; set; }
        public DbSet<WebMvcDemo2.Models.Picture> Picture { get; set; }
    }
}
//ORM   Object Relational Mapping
//  App (objects)       ->      DB (tables)