using System;
using System.Collections.Generic;
using System.Text;
using Vending_Machine.Data;
using Xunit;

namespace Vending_Machine.Tests
{
    public class ProductIdSequencerTests
    {
        // Tests NextProductId method
        [Fact]

        public void NextProductIdTests()
        {
            ProductIdSequencer.Reset();
            for (int i = 1; i < 6; i++)
            {
                int nextProductId = ProductIdSequencer.NextProductId();

                Assert.Equal(i, nextProductId);
            }

        }


        // tests Reset method
        [Theory]
        [InlineData(0)]
        [InlineData(1)]
        [InlineData(2)]
        [InlineData(3)]
        public void ResetTests(int todoId)
        {
            int expectedProductId = todoId + 1;
            int actualProductId = ProductIdSequencer.NextProductId();

            ProductIdSequencer.Reset();

            Assert.Equal(0, ProductIdSequencer.ProductId);
        }

    }
}
