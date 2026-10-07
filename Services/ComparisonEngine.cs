using PlasticInjectionApp.Models;

namespace PlasticInjectionApp.Services
{
    public static class ComparisonEngine
    {
        public static ComparisonResult Compare(Mould mould, Machine machine, double vMargin = 15, double hMargin = 15)
        {
            double effectiveVMin = machine.VMin - vMargin;
            double effectiveHMin = machine.HMin - hMargin;

            var errors = new List<string>();

            if (mould.Width < machine.WMin || mould.Width > machine.WMax)
                errors.Add($"العرض ({mould.Width}) خارج النطاق [{machine.WMin}-{machine.WMax}]");

            if (mould.Length < effectiveVMin)
                errors.Add($"الطول أقل من الحد الأدنى المقبول ({mould.Length} < {effectiveVMin})");

            if (mould.Height < effectiveHMin)
                errors.Add($"الارتفاع أقل من الحد الأدنى المقبول ({mould.Height} < {effectiveHMin})");

            if (mould.ForceVerrouillage > machine.ForceVerrouillage)
                errors.Add($"قوة غلق القالب أعلى من الآلة ({mould.ForceVerrouillage} > {machine.ForceVerrouillage})");

            if (mould.Weight > machine.PoidsMouleMax)
                errors.Add($"وزن القالب يتجاوز حمولة الآلة ({mould.Weight} > {machine.PoidsMouleMax})");

            bool isOK = errors.Count == 0;

            return new ComparisonResult
            {
                Machine = machine,
                IsCompatible = isOK,
                StatusMessage = isOK ? "مطابق ويمكن التركيب" : string.Join(" | ", errors)
            };
        }
    }
}
