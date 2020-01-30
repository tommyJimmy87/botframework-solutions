﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;

namespace Microsoft.Bot.Builder.Solutions.Skills
{
    [Obsolete("This type is being deprecated. It's moved to the assembly Microsoft.Bot.Solutions. Please refer to https://aka.ms/botframework-solutions/releases/0_8", false)]
    public enum SkillExceptionType
    {
        /// <summary>
        ///  Access Denied when calling external APIs
        /// </summary>
        APIAccessDenied,

        /// <summary>
        ///  Account Not Activated when calling external APIs
        /// </summary>
        AccountNotActivated,

        /// <summary>
        ///  Bad Request returned when calling external APIs
        /// </summary>
        APIBadRequest,

        /// <summary>
        ///  Unauthorized returned when calling external APIs
        /// </summary>
        APIUnauthorized,

        /// <summary>
        ///  Forbidden returned when calling external APIs
        /// </summary>
        APIForbidden,

        /// <summary>
        /// Other types of exceptions
        /// </summary>
        Other,
    }

    [Obsolete("This type is being deprecated. To continue using Skill capability please refer to https://aka.ms/botframework-solutions/releases/0_8")]
    public class SkillException : Exception
    {
        public SkillException(SkillExceptionType exceptionType, string message, Exception innerException)
            : base(message, innerException)
        {
            ExceptionType = exceptionType;
        }

        public SkillExceptionType ExceptionType { get; set; }
    }
}