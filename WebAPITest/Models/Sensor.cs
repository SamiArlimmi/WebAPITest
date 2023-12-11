using Microsoft.EntityFrameworkCore;

namespace WebAPITest
{
    public class Sensor
    {
        public int Id { get; set; }
        public string Navn { get; set; }

        public Sensor(string navn, int lokaleId)
        {
            Navn = navn;
        }

        public class ZealandIdDBContext : DbContext
        {
            public DbSet<Sensor> sensors { get; set; }
        }

        public Sensor()
        {

        }

        public void ValidateNavn()
        {
            if (Navn == null)
            {
                throw new ArgumentNullException("Navn m� ikke v�re null");
            }
            if (Navn.Length < 5)
            {
                throw new ArgumentOutOfRangeException("Navn skal mindst v�re p� 5 karakterer");
            }
        }

        public void Validate()
        {
            ValidateNavn();
        }

        public override string ToString()
        {
            return $"{{{nameof(Id)}={Id.ToString()}, {nameof(Navn)}={Navn}={Navn.ToString()}}}";
        }

        public override bool Equals(object? obj)
        {
            return obj is Sensor sensor &&
                   Id == sensor.Id &&
                   Navn == sensor.Navn;
        }

        public override int GetHashCode()
        {
            throw new NotImplementedException();
        }
    }
}