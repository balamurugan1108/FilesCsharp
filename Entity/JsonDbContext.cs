using Microsoft.EntityFrameworkCore;

namespace Entity
{
    public class JsonDbContext: DbContext
    {
        public JsonDbContext(DbContextOptions<JsonDbContext> options):base(options) 
        {

        }
    }
}