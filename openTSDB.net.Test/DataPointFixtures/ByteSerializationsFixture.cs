﻿using System;
using System.IO;
using System.Text;
using Epoch.net;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenTsdbNet;
using OpenTsdbNet.models;

namespace OpenTsdb.Net.Test.DataPointFixtures
{
    [TestClass]
    public class ByteSerializationsFixture
    {
        [TestMethod]
        [DeploymentItem("DataPointFixtures/DataPointSample.json")]
        public void SerializeDataPoint()
        {
            var sampleDataPoint = File.ReadAllText("DataPointFixtures/DataPointSample.json", Encoding.UTF8);

            var dataPoint = new DataPoint<int>
            {
                Value = 15,
                Metric = "testMetric",
                Timestamp = new DateTime(2015, 12, 12, 0, 0, 0, DateTimeKind.Utc).ToRawEpoch(),
                Tags = TagsCollection.New("testHost")
            };

            CollectionAssert.AreEqual(dataPoint.AsByteArray(), Encoding.UTF8.GetBytes(sampleDataPoint));
        }

        [TestMethod]
        [DeploymentItem(@"DataPointFixtures/DataPointListSample.json")]
        public void SerializeDataPointList()
        {
            var sampleDataPoints = File.ReadAllText(@"DataPointFixtures/DataPointListSample.json");

            var dataPoints = new[]
            {
                new DataPoint<int>
                {
                    Value = 15,
                    Metric = "testMetric",
                    Timestamp = new DateTime(2015, 12, 12, 0, 0, 0, DateTimeKind.Utc).ToRawEpoch(),
                    Tags = TagsCollection.New("testHost")
                },
                new DataPoint<int>
                {
                    Value = 14,
                    Metric = "testMetric",
                    Timestamp = new DateTime(2015, 12, 12, 0, 0, 0, DateTimeKind.Utc).ToRawEpoch(),
                    Tags = TagsCollection.New("testHost")
                }
            };

            CollectionAssert.AreEqual(dataPoints.AsByteArray(), Encoding.UTF8.GetBytes(sampleDataPoints));
        }
    }
}
