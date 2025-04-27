using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using BlazorApp.Models;

namespace BlazorApp.Data
{
    public class StateContext : DbContext
    {
        public StateContext (DbContextOptions<StateContext> options)
            : base(options)
        {
        }

        public virtual DbSet<State> state { get; set; } = default!;
    }
}
