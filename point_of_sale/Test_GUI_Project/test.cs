using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using FluentAssertions;
using GUI_Project_4162_4271.ViewModel;


public class UnitTest
{
    [Fact]
    public void TotalPriceTest()
    {

        // Arrange
        var viewModel = new NormalUserViewModel();
        double unit = 5;
        double price = 10;

        // Act
        double result = viewModel.TotalPriceCalc(unit, price);

        // Assert
        result.Should().Be(50); // Verify that the total price is calculated correctly
    }

}
