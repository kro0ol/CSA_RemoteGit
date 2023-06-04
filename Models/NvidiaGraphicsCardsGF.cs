using System.Xml.Linq;

namespace admLab1.Models
{
    public class NvidiaGraphicsCardsGF
    {
        public Guid Id { get; set; } = Guid.Empty;
        public string Series { get; set; }
        public string Memory { get; set; }
        public int Bits { get; set; }
        public int Price { get; set; }

        public BaseModelValidationResult Validate()
        {
            var validationResult = new BaseModelValidationResult();

            if (string.IsNullOrWhiteSpace(Series)) validationResult.Append($"Series cannot be empty");
            if (string.IsNullOrWhiteSpace(Memory)) validationResult.Append($"Memory cannot be empty");
            if (!(0 < Bits && Bits < 100)) validationResult.Append($"Bits {Bits} is out of range (2..1024)");
            if (!string.IsNullOrEmpty(Series) && !char.IsUpper(Series.FirstOrDefault())) validationResult.Append($"Series {Series} should start from capital letter");
            if (!string.IsNullOrEmpty(Memory) && !char.IsUpper(Memory.FirstOrDefault())) validationResult.Append($"Memory {Memory} should start from capital letter");
            return validationResult;
        }

        public override string ToString()
        {
            return $"{Series} {Memory} from {Price}-{Bits}";
        }
    }
}
