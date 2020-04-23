﻿using System;
using System.Threading;
using System.Threading.Tasks;
using Elasticsearch.Net;

namespace Nest
{
	public partial interface IElasticClient
	{
		/// <summary>
		/// Indices level stats provide statistics on different operations happening on an index. The API provides statistics on
		/// the index level scope (though most stats can also be retrieved using node level scope).
		/// <para> </para>
		/// http://www.elasticsearch.org/guide/en/elasticsearch/reference/current/indices-stats.html
		/// </summary>
		/// <param name="selector">Optionaly further describe the indices stats operation</param>
		IIndicesShardStoresResponse IndicesShardStores(Func<IndicesShardStoresDescriptor, IIndicesShardStoresRequest> selector = null);

		/// <inheritdoc />
		IIndicesShardStoresResponse IndicesShardStores(IIndicesShardStoresRequest request);

		/// <inheritdoc />
		Task<IIndicesShardStoresResponse> IndicesShardStoresAsync(
			Func<IndicesShardStoresDescriptor, IIndicesShardStoresRequest> selector = null,
			CancellationToken cancellationToken = default(CancellationToken)
		);

		/// <inheritdoc />
		Task<IIndicesShardStoresResponse> IndicesShardStoresAsync(IIndicesShardStoresRequest request,
			CancellationToken cancellationToken = default(CancellationToken)
		);
	}

	public partial class ElasticClient
	{
		/// <inheritdoc />
		public IIndicesShardStoresResponse IndicesShardStores(Func<IndicesShardStoresDescriptor, IIndicesShardStoresRequest> selector = null) =>
			IndicesShardStores(selector.InvokeOrDefault(new IndicesShardStoresDescriptor()));

		/// <inheritdoc />
		public IIndicesShardStoresResponse IndicesShardStores(IIndicesShardStoresRequest request) =>
			Dispatcher.Dispatch<IIndicesShardStoresRequest, IndicesShardStoresRequestParameters, IndicesShardStoresResponse>(
				request,
				(p, d) => LowLevelDispatch.IndicesShardStoresDispatch<IndicesShardStoresResponse>(p)
			);

		/// <inheritdoc />
		public Task<IIndicesShardStoresResponse> IndicesShardStoresAsync(
			Func<IndicesShardStoresDescriptor, IIndicesShardStoresRequest> selector = null,
			CancellationToken cancellationToken = default(CancellationToken)
		) => IndicesShardStoresAsync(selector.InvokeOrDefault(new IndicesShardStoresDescriptor()), cancellationToken);

		/// <inheritdoc />
		public Task<IIndicesShardStoresResponse> IndicesShardStoresAsync(IIndicesShardStoresRequest request,
			CancellationToken cancellationToken = default(CancellationToken)
		) =>
			Dispatcher
				.DispatchAsync<IIndicesShardStoresRequest, IndicesShardStoresRequestParameters, IndicesShardStoresResponse,
					IIndicesShardStoresResponse>(
					request,
					cancellationToken,
					(p, d, c) => LowLevelDispatch.IndicesShardStoresDispatchAsync<IndicesShardStoresResponse>(p, c)
				);
	}
}