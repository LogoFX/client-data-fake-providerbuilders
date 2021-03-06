﻿using Attest.Fake.Core;
using Attest.Fake.Setup;
using Attest.Fake.Setup.Contracts;

namespace LogoFX.Client.Data.Fake.ProviderBuilders
{
    /// <summary>
    /// Base provider builder with basic setup functionality.
    /// </summary>
    /// <typeparam name="TProvider">The type of the provider.</typeparam>    
    public abstract class FakeBuilderBase<TProvider> : Attest.Fake.Builders.FakeBuilderBase<TProvider> where TProvider : class
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="FakeBuilderBase{TProvider}"/> class.
        /// </summary>
        protected FakeBuilderBase()
        {
            
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="FakeBuilderBase{TProvider}"/> class
        /// with fake service instance.
        /// </summary>
        /// <param name="fake">The fake.</param>
        protected FakeBuilderBase(IFake<TProvider> fake)
            :base(fake)
        {
            
        }

        /// <summary>
        /// Creates initial template for the fake setup.
        /// </summary>
        /// <returns></returns>
        private IHaveNoMethods<TProvider> CreateInitialSetup()
        {
            return ServiceCallFactory.CreateServiceCall(FakeService);
        }

        /// <summary>
        /// Sets up the fake service calls.
        /// </summary>
        protected sealed override void SetupFake()
        {
            var initialSetup = CreateInitialSetup();
            var setup = CreateServiceCall(initialSetup);
            setup.Build();
        }

        /// <summary>
        /// Override this method to create service call from the provided template.
        /// </summary>
        /// <param name="serviceCallTemplate">The service call template.</param>
        /// <returns></returns>
        protected abstract IServiceCall<TProvider> CreateServiceCall(IHaveNoMethods<TProvider> serviceCallTemplate);
    }
}
