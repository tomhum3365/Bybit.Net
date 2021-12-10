﻿using Bybit.Net.Enums;
using Bybit.Net.Objects.Internal;
using Bybit.Net.Objects.Models;
using CryptoExchange.Net.Objects;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Bybit.Net.Clients.Rest.Futures
{
    /// <summary>
    /// Bybit account endpoints. Account endpoints include balance info, withdraw/deposit info and requesting and account settings
    /// </summary>
    public interface IBybitClientInversePerpetualApiAccount
    {
        #region Risk limit

        /// <summary>
        /// Get position risk limit
        /// <para>https://bybit-exchange.github.io/docs/inverse/#t-getrisklimit</para>
        /// </summary>
        /// <param name="symbol">The symbol</param>
        /// <param name="receiveWindow">The receive window for which this request is active. When the request takes longer than this to complete the server will reject the request</param>
        /// <param name="ct">Cancellation token</param>
        /// <returns></returns>
        Task<WebCallResult<IEnumerable<BybitRiskLimit>>> GetRiskLimitAsync(string? symbol = null, long? receiveWindow = null, CancellationToken ct = default);

        /// <summary>
        /// Set position risk
        /// <para>https://bybit-exchange.github.io/docs/inverse/#t-setrisklimit</para>
        /// </summary>
        /// <param name="symbol">The symbol</param>
        /// <param name="riskId">The risk id to set</param>
        /// <param name="mode">Position mode</param>
        /// <param name="receiveWindow">The receive window for which this request is active. When the request takes longer than this to complete the server will reject the request</param>
        /// <param name="ct">Cancellation token</param>
        /// <returns></returns>
        Task<WebCallResult<BybitRiskId>> SetRiskLimitAsync(string symbol, long riskId, PositionMode? mode = null, long? receiveWindow = null, CancellationToken ct = default);

        #endregion

        #region Positions

        /// <summary>
        /// Get user positions
        /// <para>https://bybit-exchange.github.io/docs/inverse/#t-myposition</para>
        /// </summary>
        /// <param name="symbol">Filter by symbol</param>
        /// <param name="receiveWindow">The receive window for which this request is active. When the request takes longer than this to complete the server will reject the request</param>
        /// <param name="ct">Cancellation token</param>
        /// <returns></returns>
        Task<WebCallResult<IEnumerable<BybitPosition>>> GetPositionsAsync(string? symbol = null, long? receiveWindow = null, CancellationToken ct = default);

        /// <summary>
        /// Change margin
        /// <para>https://bybit-exchange.github.io/docs/inverse/#t-changemargin</para>
        /// </summary>
        /// <param name="symbol">The symbol</param>
        /// <param name="mode">The position mode</param>
        /// <param name="margin">The margin</param>
        /// <param name="receiveWindow">The receive window for which this request is active. When the request takes longer than this to complete the server will reject the request</param>
        /// <param name="ct">Cancellation token</param>
        /// <returns></returns>
        Task<WebCallResult<decimal>> ChangeMarginAsync(string symbol, PositionMode mode, decimal margin, long? receiveWindow = null, CancellationToken ct = default);

        /// <summary>
        /// Set leverage
        /// <para>https://bybit-exchange.github.io/docs/inverse/#t-setleverage</para>
        /// </summary>
        /// <param name="symbol">The symbol</param>
        /// <param name="buyLeverage">Buy leverage</param>
        /// <param name="sellLeverage">Sell leverage</param>
        /// <param name="receiveWindow">The receive window for which this request is active. When the request takes longer than this to complete the server will reject the request</param>
        /// <param name="ct">Cancellation token</param>
        /// <returns></returns>
        Task<WebCallResult<int>> SetLeverageAsync(string symbol, int buyLeverage, int sellLeverage, long? receiveWindow = null, CancellationToken ct = default);

        /// <summary>
        /// Get user's profit and loss records
        /// <para>https://bybit-exchange.github.io/docs/inverse/#t-closedprofitandloss</para>
        /// </summary>
        /// <param name="symbol">The symbol to get records for</param>
        /// <param name="startTime">Filter by startTime</param>
        /// <param name="endTime">Filter by endTime</param>
        /// <param name="type">Filter by type</param>
        /// <param name="page">Page</param>
        /// <param name="pageSize">Page size</param>
        /// <param name="receiveWindow">The receive window for which this request is active. When the request takes longer than this to complete the server will reject the request</param>
        /// <param name="ct">Cancellation token</param>
        /// <returns></returns>
        Task<WebCallResult<BybitPage<IEnumerable<BybitPnlEntry>>>> GetProfitAndLossHistoryAsync(string symbol, DateTime? startTime = null, DateTime? endTime = null, TradeType? type = null, int? page = null, int? pageSize = null, long? receiveWindow = null, CancellationToken ct = default);

        /// <summary>
        /// Switch between full or partial Stop loss/Take profit mode
        /// <para>https://bybit-exchange.github.io/docs/inverse/#t-switchmode</para>
        /// </summary>
        /// <param name="symbol">The symbol</param>
        /// <param name="mode">New mode</param>
        /// <param name="receiveWindow">The receive window for which this request is active. When the request takes longer than this to complete the server will reject the request</param>
        /// <param name="ct">Cancellation token</param>
        /// <returns></returns>
        Task<WebCallResult<BybitTpSlMode>> SetFullPartialPositionModeAsync(string symbol, StopLossTakeProfitMode mode, long? receiveWindow = null, CancellationToken ct = default);

        /// <summary>
        /// Switch between cross and isolated mode.
        /// <para>https://bybit-exchange.github.io/docs/inverse/#t-marginswitch</para>
        /// </summary>
        /// <param name="symbol">The symbol</param>
        /// <param name="isIsolated">Is isolated</param>
        /// <param name="buyLeverage">Buy leverage</param>
        /// <param name="sellLeverage">Sell leverage</param>
        /// <param name="receiveWindow">The receive window for which this request is active. When the request takes longer than this to complete the server will reject the request</param>
        /// <param name="ct">Cancellation token</param>
        /// <returns></returns>
        Task<WebCallResult> SetIsolatedModeAsync(string symbol, bool isIsolated, decimal buyLeverage, decimal sellLeverage, long? receiveWindow = null, CancellationToken ct = default);

        #endregion

        #region Wallet

        /// <summary>
        /// Get wallet balances
        /// <para>https://bybit-exchange.github.io/docs/inverse/#t-balance</para>
        /// </summary>
        /// <param name="asset">Filter by asset</param>
        /// <param name="receiveWindow">The receive window for which this request is active. When the request takes longer than this to complete the server will reject the request</param>
        /// <param name="ct">Cancellation token</param>
        /// <returns></returns>
        Task<WebCallResult<Dictionary<string, BybitBalance>>> GetBalancesAsync(string? asset = null, long? receiveWindow = null, CancellationToken ct = default);

        /// <summary>
        /// Get wallet fund endpoints
        /// <para>https://bybit-exchange.github.io/docs/inverse/#t-walletrecords</para>
        /// </summary>
        /// <param name="asset">Filter by asset</param>
        /// <param name="startTime">Filter by start time</param>
        /// <param name="endTime">Filter by end time</param>
        /// <param name="type">Filter by type</param>
        /// <param name="pageSize">Page size</param>
        /// <param name="page">Page</param>
        /// <param name="receiveWindow">The receive window for which this request is active. When the request takes longer than this to complete the server will reject the request</param>
        /// <param name="ct">Cancellation token</param>
        /// <returns></returns>
        Task<WebCallResult<IEnumerable<BybitWalletFundRecord>>> GetWalletFundHistoryAsync(string? asset = null, DateTime? startTime = null, DateTime? endTime = null, WalletFundType? type = null, int? pageSize = null, int? page = null, long? receiveWindow = null, CancellationToken ct = default);

        /// <summary>
        /// Get withdrawal history
        /// <para>https://bybit-exchange.github.io/docs/inverse/#t-withdrawrecords</para>
        /// </summary>
        /// <param name="asset">Filter by asset</param>
        /// <param name="startTime">Filter by start time</param>
        /// <param name="endTime">Filter by end time</param>
        /// <param name="status">Filter by status</param>
        /// <param name="pageSize">Page size</param>
        /// <param name="page">Page</param>
        /// <param name="receiveWindow">The receive window for which this request is active. When the request takes longer than this to complete the server will reject the request</param>
        /// <param name="ct">Cancellation token</param>
        /// <returns></returns>
        Task<WebCallResult<IEnumerable<BybitWithdrawal>>> GetWithdrawalHistoryAsync(string? asset = null, DateTime? startTime = null, DateTime? endTime = null, WithdrawStatus? status = null, int? pageSize = null, int? page = null, long? receiveWindow = null, CancellationToken ct = default);

        /// <summary>
        /// Get asset exchange history
        /// <para>https://bybit-exchange.github.io/docs/inverse/#t-assetexchangerecords</para>
        /// </summary>
        /// <param name="fromId">Filter by id</param>
        /// <param name="direction">Filter by direction</param>
        /// <param name="limit">Max records</param>
        /// <param name="receiveWindow">The receive window for which this request is active. When the request takes longer than this to complete the server will reject the request</param>
        /// <param name="ct">Cancellation token</param>
        /// <returns></returns>
        Task<WebCallResult<IEnumerable<BybitExchangeHistoryEntry>>> GetAssetExchangeHistoryAsync(long? fromId = null, SearchDirection? direction = null, int? limit = null, long? receiveWindow = null, CancellationToken ct = default);

        #endregion

        #region Funding

        /// <summary>
        /// Get user last funding fee
        /// <para>https://bybit-exchange.github.io/docs/inverse/#t-mylastfundingfee</para>
        /// </summary>
        /// <param name="symbol">The symbol</param>
        /// <param name="receiveWindow">The receive window for which this request is active. When the request takes longer than this to complete the server will reject the request</param>
        /// <param name="ct">Cancellation token</param>
        /// <returns></returns>
        Task<WebCallResult<BybitFundingSettlement>> GetLastUserFundingFeeAsync(string symbol, long? receiveWindow = null, CancellationToken ct = default);

        /// <summary>
        /// Get predicted next funding rate
        /// <para>https://bybit-exchange.github.io/docs/inverse/#t-predictedfunding</para>
        /// </summary>
        /// <param name="symbol">The symbol</param>
        /// <param name="receiveWindow">The receive window for which this request is active. When the request takes longer than this to complete the server will reject the request</param>
        /// <param name="ct">Cancellation token</param>
        /// <returns></returns>
        Task<WebCallResult<BybitPredictedFunding>> GetPredictedUserFundingFeeAsync(string symbol, long? receiveWindow = null, CancellationToken ct = default);

        #endregion

        /// <summary>
        /// Get Api key info
        /// <para>https://bybit-exchange.github.io/docs/inverse/#t-key</para>
        /// </summary>
        /// <param name="receiveWindow">The receive window for which this request is active. When the request takes longer than this to complete the server will reject the request</param>
        /// <param name="ct">Cancellation token</param>
        /// <returns></returns>
        Task<WebCallResult<IEnumerable<ByBitApiKeyInfo>>> GetApiKeyInfoAsync(long? receiveWindow = null, CancellationToken ct = default);
    }
}