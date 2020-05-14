﻿using LeanTest.L0Tests.ExternalDependencies;
using LeanTest.L0Tests.Mocks;
using LeanTest.L0Tests.Readers;
using LeanTest.L0Tests.TestData;
using LeanTest.Mock;
using Microsoft.Extensions.DependencyInjection;

namespace LeanTest.L0Tests.TestSetup.IoC
{
	public static class L0CompositionRootForTest
	{
		public static IServiceCollection Initialize(IServiceCollection serviceCollection)
		{
			// Mock-for-data:
			serviceCollection.RegisterMockForData<IExternalDependency, MockForDataExternalDependency, DataWithOneMock, DataWithTwoMocks>();
			serviceCollection.RegisterMockForData<IExternalDependency, AnotherMockForDataExternalDependency, DataWithTwoMocks>();

			// Readers:
			serviceCollection.AddSingleton<DataWithOneMockReader>();
			serviceCollection.AddSingleton<DataWithTwoMocksReader>();

			return serviceCollection;
		}

		private static void RegisterMockForData<TInterface, TImplementation, TData1>(this IServiceCollection container)
			where TImplementation: class, TInterface, IMockForData<TData1>
			where TInterface: class
		{
			container.AddSingleton<TImplementation>();
			container.AddSingleton<TInterface>(x => x.GetRequiredService<TImplementation>());
			container.AddSingleton<IMockForData<TData1>>(x => x.GetRequiredService<TImplementation>());
		}

		private static void RegisterMockForData<TInterface, TImplementation, TData1, TData2>(this IServiceCollection container)
			where TImplementation: class, TInterface, IMockForData<TData1>, IMockForData<TData2>
			where TInterface: class
		{
			container.AddSingleton<TImplementation>();
			container.AddSingleton<TInterface>(x => x.GetRequiredService<TImplementation>());
			container.AddSingleton<IMockForData<TData1>>(x => x.GetRequiredService<TImplementation>());
			container.AddSingleton<IMockForData<TData2>>(x => x.GetRequiredService<TImplementation>());
		}
	}
}