﻿using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenTsdbNet;
using OpenTsdbNet.models;

namespace OpenTsdb.Net.Test.Integration
{
    [TestClass]
    public class OpenTsdbIntegrationFixture
    {
        private const string _openTsdbUrl = "http://11.0.0.101:4242";

        [TestMethod]
        [Ignore("Only for integration purposes. !! Must refactor !!")]
        public void SubmitSinglePointData()
        {
            var pushResult = OpenTsdbFactory
                .Instance(TsdbOptions.New(_openTsdbUrl))
                .PushAsync("ping", new Random().Next());

            Assert.AreEqual(pushResult.Result.ResponseHttpStatusCode, 204);
        }
    }
}