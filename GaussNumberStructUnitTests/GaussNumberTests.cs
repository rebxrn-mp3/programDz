using NUnit.Framework;
using GaussNumberStruct;

namespace GaussNumberStructUnitTests
{
    [TestFixture]
    public class GaussNumberTests
    {
        [Test]
        public void ConstructorTest()
        {
            var g = new GaussNumber(3.5, -2.1);
            Assert.That(g.Re, Is.EqualTo(3.5));
            Assert.That(g.Im, Is.EqualTo(-2.1));
        }

        [Test]
        public void NormaTest()
        {
            var g = new GaussNumber(3, 4);
            Assert.That(g.Norma, Is.EqualTo(25));
        }

        [TestCase(0, 0, "0")]
        [TestCase(5, 0, "5")]
        [TestCase(0, 1, "i")]
        [TestCase(0, -1, "-i")]
        [TestCase(3, 2, "3 + 2i")]
        [TestCase(3, -2, "3 - 2i")]
        public void ToStringTest(double re, double im, string expected)
        {
            var g = new GaussNumber(re, im);
            Assert.That(g.ToString(), Is.EqualTo(expected));
        }

        [TestCase(1, 2, 1, 2, true)]
        [TestCase(1, 2, 1, 3, false)]
        public void EqualsTest(double re1, double im1, double re2, double im2, bool result)
        {
            var a = new GaussNumber(re1, im1);
            var b = new GaussNumber(re2, im2);
            Assert.That(a.Equals(b), Is.EqualTo(result));
        }

        [Test]
        public void ConjugateOperatorTest()
        {
            var g = new GaussNumber(3, 4);
            var conjugate = ~g;
            Assert.That(conjugate.Re, Is.EqualTo(3));
            Assert.That(conjugate.Im, Is.EqualTo(-4));
        }

        [Test]
        public void AdditionOperatorTest()
        {
            var a = new GaussNumber(1, 2);
            var b = new GaussNumber(3, 4);
            var sum = a + b;
            Assert.That(sum.Re, Is.EqualTo(4));
            Assert.That(sum.Im, Is.EqualTo(6));
        }

        [Test]
        public void MultiplicationOperatorTest()
        {
            var a = new GaussNumber(1, 2);
            var b = new GaussNumber(3, 4);
            var product = a * b;
            Assert.That(product.Re, Is.EqualTo(-5));
            Assert.That(product.Im, Is.EqualTo(10));
        }
    }
}