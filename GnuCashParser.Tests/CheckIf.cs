using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GnuCashParser.Tests
{
    public static class CheckIf
    {
        public static void EqualId(string expectedId, Guid actualId, string message)
        {
            Assert.AreEqual(Guid.Parse(expectedId), actualId, message);
        }
    }
}
