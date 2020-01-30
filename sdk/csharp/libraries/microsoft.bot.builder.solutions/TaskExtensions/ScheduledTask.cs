﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using NCrontab;

namespace Microsoft.Bot.Builder.Solutions.TaskExtensions
{
    [Obsolete("This type is being deprecated. It's moved to the assembly Microsoft.Bot.Solutions. Please refer to https://aka.ms/botframework-solutions/releases/0_8", false)]
    public class ScheduledTask : ScheduledProcessor
    {
        private readonly object lockObject = new object();

        public ScheduledTask(IBackgroundTaskQueue backgroundTaskQueue)
            : base(backgroundTaskQueue)
        {
        }

        public void AddScheduledTask(ScheduledTaskModel scheduledTask)
        {
            if (scheduledTask == null)
            {
                throw new ArgumentNullException("ScheduledTask cannot be null!");
            }

            if (string.IsNullOrWhiteSpace(scheduledTask.ScheduleExpression))
            {
                throw new ArgumentException("ScheduledTask has to have a schedule expression!");
            }

            if (CrontabSchedule.Parse(scheduledTask.ScheduleExpression) == null)
            {
                throw new ArgumentException("ScheduledTask has to have a legal schedule expression!");
            }

            if (scheduledTask.Task == null)
            {
                throw new ArgumentException("ScheduledTask has to have a task");
            }

            lock (lockObject)
            {
                Schedules.Add(scheduledTask);
            }
        }
    }
}