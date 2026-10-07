namespace PlasticInjectionApp.Models
{
    public class Machine
    {
        public string Code { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public double WMin { get; set; }
        public double WMax { get; set; }
        public double VMin { get; set; }
        public double HMin { get; set; }
        public double ForceVerrouillage { get; set; }
        public double PoidsMouleMax { get; set; }
    }

    public class Mould
    {
        public string Code { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public double Width { get; set; }
        public double Length { get; set; }
        public double Height { get; set; }
        public double ForceVerrouillage { get; set; }
        public double Weight { get; set; }
    }

    public class ComparisonResult
    {
        public Machine Machine { get; set; }
        public bool IsCompatible { get; set; }
        public string StatusMessage { get; set; }
    }
}
