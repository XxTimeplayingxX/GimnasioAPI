using GimnasioAPI.MODELS;
using Microsoft.EntityFrameworkCore;

namespace GimnasioAPI.DATA
{
    public class GimnasioDbContext : DbContext
    {
        public GimnasioDbContext(DbContextOptions<GimnasioDbContext> options)
            : base(options)
        {
            
        }
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Planes> Planes { get; set; }
        public DbSet<UsuarioPlanes> UsuarioPlanes { get; set; }
        public DbSet<Sucursal> Sucursales { get; set; }
        public DbSet<UsuarioSucursal> UsuarioSucursales { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Sembrado de datos para la clase Planes
            var plan1 = new Planes { ID = 1, Plan = "Plan Premium", Precio = 39.99, Beneficios = "Puedes acceder a todas las maquinas, actividades del gimnasio" };
            var plan2 = new Planes { ID = 2, Plan = "Plan Platino", Precio = 59.99, Beneficios = "Tienes los beneficios del plan Premium, más CrossFit y acceso a todas las sucursales" };
            modelBuilder.Entity<Planes>().HasData(new Planes[] { plan1, plan2 });

            // Sembrado de datos para la clase Sucursal
            var sucursal1 = new Sucursal { ID = 1, Nombre = "Sucursal Centro", Dirección = "Centro de Guayaquil", HoraDeApertura = DateTime.Parse("08:00"), HoraDeCierre = DateTime.Parse("18:00") };
            var sucursal2 = new Sucursal { ID = 2, Nombre = "Sucursal Centro Comercial el Dorado", Dirección = "Centro Comercial el Dorado", HoraDeApertura = DateTime.Parse("09:00"), HoraDeCierre = DateTime.Parse("19:00") };
            modelBuilder.Entity<Sucursal>().HasData(new Sucursal[] { sucursal1, sucursal2 });

            // Sembrado de datos para la clase Usuario
            var usuario1 = new Usuario { ID = 1, Nombre = "Juan", Apellido = "Pérez", Cedula = "1234567890", Direccion = "Juan Tan Ca Marengo" };
            var usuario2 = new Usuario { ID = 2, Nombre = "María", Apellido = "González", Cedula = "0987654321", Direccion = "Av. Francisco de Orellana" };
            modelBuilder.Entity<Usuario>().HasData(new Usuario[] { usuario1, usuario2 });

            // Sembrado de datos para la clase UsuarioPlanes
            var usuarioPlanes1 = new UsuarioPlanes { ID = 1, UsuarioID = 1, PlanesID = 1 };
            var usuarioPlanes2 = new UsuarioPlanes { ID = 2, UsuarioID = 2, PlanesID = 2 };
            modelBuilder.Entity<UsuarioPlanes>().HasData(new UsuarioPlanes[] { usuarioPlanes1, usuarioPlanes2 });

            // Sembrado de datos para la clase UsuarioSucursal
            var usuarioSucursal1 = new UsuarioSucursal { ID = 1, UsuarioID = 1, SucursalID = 1 };
            var usuarioSucursal2 = new UsuarioSucursal { ID = 2, UsuarioID = 2, SucursalID = 2 };
            modelBuilder.Entity<UsuarioSucursal>().HasData(new UsuarioSucursal[] { usuarioSucursal1, usuarioSucursal2 });



            base.OnModelCreating(modelBuilder);
        }
    }
}
