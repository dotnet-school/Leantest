﻿using System.Diagnostics.CodeAnalysis;
using System.Linq;
using LeanTest.L0Tests.ExternalDependencies;
using LeanTest.L0Tests.TestData;
using LeanTest.Mock;

namespace LeanTest.L0Tests.Mocks
{
	[SuppressMessage("ReSharper", "ClassNeverInstantiated.Global", Justification = "Instantiated by the IoC container.")]
	internal class MockForDataExternalDependency : TypedData<DataWithOneMock>, IExternalDependency, 
		IMockForData<DataWithOneMock>, IMockForData<DataWithTwoMocks>
	{
		internal DataWithOneMock DataWithOneMock => Data.First();
		internal DataWithTwoMocks DataWithTwoMocks { get; private set; }
		public void WithData(DataWithTwoMocks data) => DataWithTwoMocks = data;
	}
	[SuppressMessage("ReSharper", "ClassNeverInstantiated.Global", Justification = "Instantiated by the IoC container.")]
	internal class AnotherMockForDataExternalDependency : TypedData<DataWithTwoMocks>, IExternalDependency, 
		IMockForData<DataWithTwoMocks>
	{
		internal DataWithTwoMocks DataWithTwoMocks => Data.First();
	}
}