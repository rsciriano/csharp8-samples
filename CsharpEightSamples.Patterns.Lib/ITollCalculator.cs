using System;
using System.Collections.Generic;
using System.Text;

namespace CsharpEightSamples.Patterns.Lib
{
    // I made this interface so I can usethe same test routine
    // with each iteration of the toll calculator
    public interface ITollCalculator
    {
        decimal CalculateToll(object vehicle);
    }
}
