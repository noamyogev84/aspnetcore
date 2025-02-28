﻿// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using System;
using Microsoft.AspNetCore.Rewrite.PatternSegments;
using Xunit;

namespace Microsoft.AspNetCore.Rewrite.Tests.PatternSegments
{
    public class DateTimeSegmentTests
    {
        [Theory]
        [InlineData("TIME_YEAR")]
        [InlineData("TIME_MON")]
        [InlineData("TIME_DAY")]
        [InlineData("TIME_HOUR")]
        [InlineData("TIME_MIN")]
        [InlineData("TIME_SEC")]
        [InlineData("TIME_WDAY")]
        [InlineData("TIME")]
        public void DateTime_AssertDoesntThrowOnCheckOfSegment(string input)
        {
            // Arrange
            var segment = new DateTimeSegment(input);

            // Act
            var results = segment.Evaluate(null, null, null);

            // TODO testing dates is hard, could use moq
            // currently just assert that the segment doesn't throw.
        }

        [Theory]
        [InlineData("foo", "Unsupported segment: 'foo'")]
        [InlineData("wow", "Unsupported segment: 'wow'")]
        public void DateTime_AssertThrowsOnInvalidInput(string input, string expected)
        {
            // Act And Assert
            var ex = Assert.Throws<FormatException>(() => new DateTimeSegment(input));
            Assert.Equal(expected, ex.Message);
        }
    }
}
