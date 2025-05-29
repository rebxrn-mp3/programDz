using System;

namespace GaussNumberStruct
{
    public struct GaussNumber
    {
        public double Re { get; }
        public double Im { get; }
        public double Norma => Re * Re + Im * Im;

        public GaussNumber(double re, double im)
        {
            Re = re;
            Im = im;
        }

        public override string ToString()
        {
            if (Re == 0 && Im == 0) return "0";
            if (Im == 0) return $"{Re}";
            if (Re == 0) return $"{(Im == 1 ? "" : Im == -1 ? "-" : Im.ToString())}i";

            string sign = Im > 0 ? "+" : "";
            string imPart = Math.Abs(Im) == 1 ? "i" : $"{Math.Abs(Im)}i";
            if (Im < 0) sign = "-";

            return $"{Re} {sign} {imPart}";
        }

        public override bool Equals(object obj)
        {
            if (obj is GaussNumber other)
            {
                const double tolerance = 1e-13;
                return Math.Abs(Re - other.Re) < tolerance &&
                       Math.Abs(Im - other.Im) < tolerance;
            }
            throw new ArgumentException("Объект не является гауссовым числом");
        }

        public override int GetHashCode()
        {
            unchecked
            {
                int hash = 17;
                hash = hash * 23 + Re.GetHashCode();
                hash = hash * 23 + Im.GetHashCode();
                return hash;
            }
        }

        public static GaussNumber operator ~(GaussNumber g) => new GaussNumber(g.Re, -g.Im);
        public static GaussNumber operator +(GaussNumber a, GaussNumber b) => new GaussNumber(a.Re + b.Re, a.Im + b.Im);
        public static GaussNumber operator *(GaussNumber a, GaussNumber b) =>
            new GaussNumber(a.Re * b.Re - a.Im * b.Im, a.Re * b.Im + a.Im * b.Re);

        public static bool operator ==(GaussNumber a, GaussNumber b) => a.Equals(b);
        public static bool operator !=(GaussNumber a, GaussNumber b) => !a.Equals(b);
    }
}