using Microsoft.EntityFrameworkCore;

namespace ProfilesApi.DB
{
    public class ProfileContext : DbContext
    {
        public ProfileContext(DbContextOptions<ProfileContext> options)
            : base(options)
        {
        }

        public DbSet<Profile> Profiles { get; set; }
    }
}