using Xunit;
using FsCheck.Xunit;
using FsCheck;
using System.Linq;
using System.Collections.Generic;

namespace DiamondKata
{
    public class DiamondKataTest
    {
        private string[] Rows(string diamond) => diamond.Split('\n');
        private List<char> GetRange(char endpoint) => Enumerable.Range('A', endpoint).Select(c => (char)c).ToList();

        [DiamondProperty]
        public void Diamond_is_not_empty(char letter)
        {
            var diamond = Diamond.Make(letter);

            Assert.NotEmpty(diamond);
        }

        [DiamondProperty]
        public void First_row_contains_A(char letter)
        {
            var diamond = Diamond.Make(letter);
            var rows = Rows(diamond);

            Assert.Equal("A", rows.First());
        }

        [DiamondProperty]
        public void Last_row_contains_A(char letter)
        {
            var diamond = Diamond.Make(letter);
            var rows = Rows(diamond);

            Assert.Equal("A", rows.Last());
        }
    }

    public class DiamondPropertyAttribute : PropertyAttribute
    {
        public DiamondPropertyAttribute()
        {
            Arbitrary = new[] { typeof(LettersOnlyArbitrary) };
        }
    }

    public static class LettersOnlyArbitrary
    {
        public static Arbitrary<char> Chars()
        {
            return Arb.Default.Char().Filter(c => c >= 'A' && c <= 'Z');
        }
    }
}
