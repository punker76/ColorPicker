﻿using System;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using Vector = System.Collections.Generic.IReadOnlyList<double>;

namespace ColorPicker.ColorModels
{
    /// <summary>
    ///     LMS color space represented by the response of the three types of cones of the human eye
    /// </summary>
    public readonly struct LMSColor : IColorVector
    {

        /// <param name="vector"><see cref="Vector"/>, expected 3 dimensions (usually from 0 to 1) </param>
        public LMSColor(Vector vector) : this(vector[0], vector[1], vector[2])
        {
        }

        /// <param name="l"> L (usually from -1 to 1) </param>
        /// <param name="m"> M (usually from -1 to 1) </param>
        /// <param name="s"> S (usually from -1 to 1) </param>
        public LMSColor(double l, double m, double s)
        {
            L = l;
            M = m;
            S = s;
        }

        /// <inheritdoc cref="object"/>
        public static bool operator !=(LMSColor left, LMSColor right)
        {
            return !Equals(left, right);
        }

        /// <inheritdoc cref="object"/>
        public static bool operator ==(LMSColor left, LMSColor right)
        {
            return Equals(left, right);
        }


        /// <inheritdoc cref="object"/>
        [SuppressMessage("ReSharper", "CompareOfFloatsByEqualityOperator")]
        public bool Equals(LMSColor other) { return (L == other.L) && (M == other.M) && (S == other.S); }

        /// <inheritdoc cref="object"/>
        public override bool Equals(object obj) { return (obj is LMSColor other) && Equals(other); }

        /// <inheritdoc cref="object"/>
        public override int GetHashCode()
        {
            unchecked
            {
                int hashCode = L.GetHashCode();
                hashCode = (hashCode * 397) ^ M.GetHashCode();
                hashCode = (hashCode * 397) ^ S.GetHashCode();
                return hashCode;
            }
        }


        /// <inheritdoc cref="object"/>
        public override string ToString() { return string.Format(CultureInfo.InvariantCulture, "LMS [L={0:0.##}, M={1:0.##}, S={2:0.##}]", L, M, S); }


        /// <summary>
        ///     Long wavelengths (red) cone response (Rho)
        /// </summary>
        /// <remarks>
        ///     Ranges usually from -1 to 1.
        /// </remarks>
        public double L { get; }

        /// <summary>
        ///     Medium wavelengths (green) cone response (Gamma)
        /// </summary>
        /// <remarks>
        ///     Ranges usually from -1 to 1.
        /// </remarks>
        public double M { get; }

        /// <summary>
        ///     Short wavelengths (blue) cone response (Beta)
        /// </summary>
        /// <remarks>
        ///     Ranges usually from -1 to 1.
        /// </remarks>
        public double S { get; }


        /// <summary>
        ///     <see cref="IColorVector"/>
        /// </summary>
        public Vector Vector => new[] { L, M, S };

    }
}