﻿// =-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-
// libWyvernzora/MappedComparer.cs
// --------------------------------------------------------------------------------
// Copyright (c) 2013, Jieni Luchijinzhou a.k.a Aragorn Wyvernzora
// 
// This file is a part of libWyvernzora.
// 
// Permission is hereby granted, free of charge, to any person obtaining a copy 
// of this software and associated documentation files (the "Software"), to deal 
// in the Software without restriction, including without limitation the rights 
// to use, copy, modify, merge, publish, distribute, sublicense, and/or sell copies 
// of the Software, and to permit persons to whom the Software is furnished to do 
// so, subject to the following conditions:
// 
// The above copyright notice and this permission notice shall be included in all 
// copies or substantial portions of the Software.
// 
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, 
// INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, FITNESS FOR A 
// PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT 
// HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION 
// OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE 
// SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.
// =-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-

using System;
using System.Collections.Generic;

namespace libWyvernzora.Collections
{
    /// <summary>
    ///     IComparer implementation that maps input values to other values before
    ///     comparing them.
    /// </summary>
    /// <typeparam name="TInput">Type of input values.</typeparam>
    /// <typeparam name="TMap">Type of mapped values.</typeparam>
    public class MappedComparer<TInput, TMap> : IComparer<TInput>
    {
        private readonly Func<TInput, TMap> map;
        private readonly IComparer<TMap> mapComparer;

        /// <summary>
        ///     Constructor.
        ///     Initializes a new instance.
        /// </summary>
        /// <param name="map">Mapping function.</param>
        public MappedComparer(Func<TInput, TMap> map)
            : this(map, Comparer<TMap>.Default)
        {
        }

        /// <summary>
        ///     Constructor.
        ///     Initializes a new instance.
        /// </summary>
        /// <param name="map">Mapping function.</param>
        /// <param name="mapComparer">IComparer for comparing mapped values.</param>
        public MappedComparer(Func<TInput, TMap> map, IComparer<TMap> mapComparer)
        {
            if (map == null)
                throw new ArgumentNullException("map");
            if (mapComparer == null)
                throw new ArgumentNullException("mapComparer");

            this.map = map;
            this.mapComparer = mapComparer;
        }

        public int Compare(TInput x, TInput y)
        {
            return mapComparer.Compare(map(x), map(y));
        }
    }
}