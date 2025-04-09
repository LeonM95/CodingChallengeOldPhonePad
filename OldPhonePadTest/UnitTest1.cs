using CodingChallengeOldPhonePad;

namespace OldPhonePadTest
{
    public class UnitTest1
    {
        // Basic test for E
        [Fact]
        public void TestForOneChar()
        {
            var output = Program.OldPhonePad("2#");

            Assert.Equal("E", output);
        }

        // Basic test for B
        [Fact]
        public void TestForOneChar2()
        {
            var output = Program.OldPhonePad("227*#");

            Assert.Equal("B", output);
        }

        // Test with output = hello
        [Fact]
        public void HelloTest()
        {
            var result = Program.OldPhonePad("4433555 555666#");
            Assert.Equal("HELLO", result);
        }

        // test to delete the turing
        [Fact]
        public void DeleteCharTest()
        {
            var result = Program.OldPhonePad("8 88777444666*664");
            Assert.Equal("TURING", result);
        }


        // to test empty output
        [Fact]
        public void EmptyInputTest()
        {
            var result = Program.OldPhonePad("#");
            Assert.Equal("", result);
        }
    }
}
