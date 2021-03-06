﻿using System;
using Shouldly.Tests.Strings;
using Xunit;

namespace Shouldly.Tests.ShouldBe.WithTolerance
{
    public class DateTimeScenario
    {
        [Fact]
        public void DateTimeScenarioShouldFail()
        {
            var date = new DateTime(2000, 6, 1);
            var dateString = date.ToString();
            var expected = new DateTime(2000, 6, 1, 1, 0, 1);
            var expectedString = expected.ToString();
            Verify.ShouldFail(() =>
date.ShouldBe(expected, TimeSpan.FromHours(1), "Some additional context"),

errorWithSource:
$@"date
    should be within
01:00:00
    of
{expectedString}
    but was
{dateString}

Additional Info:
    Some additional context",

errorWithoutSource:
$@"{dateString}
    should be within
01:00:00
    of
{expectedString}
    but was not

Additional Info:
    Some additional context");
        }

        [Fact]
        public void ShouldPass()
        {
            var date = new DateTime(2000, 6, 1);
            date.ShouldBe(new DateTime(2000, 6, 1, 1, 0, 1), TimeSpan.FromHours(1.5d));
        }
    }
}
