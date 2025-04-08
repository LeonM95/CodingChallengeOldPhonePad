using CodingChallengeOldPhonePad;

namespace OldPhonePadTest
{
    public class UnitTest1
    {
        // Basic test for single letter
        [Fact]
        public void TestForOneChar()
        {
            // to test press 1 key
            var output = Program.OldPhonePad("2#");

            Assert.Equal("A", output);
        }



        // test to delete the last char
        [Fact]
        public void DeleteCharTest()
        {
            var result = Program.OldPhonePad("227*#");
            Assert.Equal("B", result);
        }

        // Test with output = hello
        [Fact]
        public void HelloTest()
        {
            var result = Program.OldPhonePad("4433555 555666#");
            Assert.Equal("HELLO", result);
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