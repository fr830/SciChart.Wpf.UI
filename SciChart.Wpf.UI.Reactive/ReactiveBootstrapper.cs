﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive.Concurrency;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Practices.Unity;
using SciChart.Wpf.UI.Reactive.Async;
using SciChart.Wpf.UI.Reactive.Bootstrap;
using SciChart.Wpf.UI.Reactive.Observability;

namespace SciChart.WPF.UI.Reactive
{
    class ReactiveBootstrapper : AbtBootstrapper
    {
        public ReactiveBootstrapper(IUnityContainer container, IAttributedTypeDiscoveryService attributedTypeDiscovery) 
            : base(container, attributedTypeDiscovery)
        {
        }

        public override void Initialize()
        {
            var sc = new SchedulerContext(
                new SharedScheduler(TaskScheduler.FromCurrentSynchronizationContext(), DispatcherScheduler.Current),
                new SharedScheduler(TaskScheduler.Default, Scheduler.Default));
            Container.RegisterInstance<ISchedulerContext>(sc);
            ObservableObjectBase.DispatcherSynchronizationContext = SynchronizationContext.Current;

            base.Initialize();
        }
    }
}
