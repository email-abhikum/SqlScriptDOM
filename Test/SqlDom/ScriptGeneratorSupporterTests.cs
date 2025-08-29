//------------------------------------------------------------------------------
// <copyright file="ScriptGeneratorSupporterTests.cs" company="Microsoft">
//         Copyright (c) Microsoft Corporation.  All rights reserved.
// </copyright>
//------------------------------------------------------------------------------

using System;
using Microsoft.SqlServer.TransactSql.ScriptDom.ScriptGenerator;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SqlStudio.Tests.AssemblyTools.TestCategory;

namespace SqlStudio.Tests.UTSqlScriptDom
{
    [TestClass]
    public class ScriptGeneratorSupporterTests
    {
        [TestMethod]
        [Priority(0)]
        [SqlStudioTestCategory(Category.UnitTest)]
        public void GetPascalCase_ReturnsEmptyString_ForEmptyInput()
        {
            Assert.AreEqual(string.Empty, ScriptGeneratorSupporter.GetPascalCase(string.Empty));
        }

        [TestMethod]
        [Priority(0)]
        [SqlStudioTestCategory(Category.UnitTest)]
        public void GetPascalCase_ThrowsArgumentNullException_ForNullInput()
        {
            Assert.ThrowsException<ArgumentNullException>(() => ScriptGeneratorSupporter.GetPascalCase(null));
        }
    }
}

