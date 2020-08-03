﻿using System;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using Vector = System.Collections.Generic.IReadOnlyList<double>;


namespace ColorPicker.ColorModels
{
    /// <summary>
    ///     CIE L*u*v* (1976) color
    /// </summary>
    public readonly struct LuvColor : IColorVector
    {

        /// <summary>
        ///     D65 standard illuminant. Used when reference white is not specified explicitly.
        /// </summary>
        public static readonly XYZColor DefaultWhitePoint = Illuminants.D65;

        private readonly XYZColor? _whitePoint;

        /// <param name="vector"><see cref="Vector"/>, expected 3 dimensions </param>
        /// <remarks> Uses <see cref="DefaultWhitePoint"/> as white point. </remarks>
        public LuvColor(Vector vector) : this(vector, DefaultWhitePoint)
        {
        }

        /// <param name="vector"><see cref="Vector"/>, expected 3 dimensions </param>
        /// <param name="whitePoint"> Reference white (see <see cref="Illuminants"/>) </param>
        public LuvColor(Vector vector, XYZColor whitePoint) : this(vector[0], vector[1], vector[2], whitePoint)
        {
        }


        /// <param name="l"> L* (lightness) (from 0 to 100) </param>
        /// <param name="u"> u* (usually from -100 to 100) </param>
        /// <param name="v"> v* (usually from -100 to 100) </param>
        /// <remarks> Uses <see cref="DefaultWhitePoint"/> as white point. </remarks>
        public LuvColor(double l, double u, double v) : this(l, u, v, DefaultWhitePoint)
        {
        }

        /// <param name="l"> L* (lightness) (from 0 to 100) </param>
        /// <param name="u"> u* (usually from -100 to 100) </param>
        /// <param name="v"> v* (usually from -100 to 100) </param>
        /// <param name="whitePoint"> Reference white (see <see cref="Illuminants"/>) </param>
        public LuvColor(double l, double u, double v, XYZColor whitePoint)
        {
            L = l;
            this.u = u;
            this.v = v;
            _whitePoint = whitePoint;
        }

        /// <inheritdoc cref="object"/>
        public static bool operator !=(LuvColor left, LuvColor right)
        {
            return !Equals(left, right);
        }

        /// <inheritdoc cref="object"/>
        public static bool operator ==(LuvColor left, LuvColor right)
        {
            return Equals(left, right);
        }


        /// <inheritdoc cref="object"/>
        [SuppressMessage("ReSharper", "CompareOfFloatsByEqualityOperator")]
        public bool Equals(LuvColor other) { return (L == other.L) && (u == other.u) && (v == other.v); }

        /// <inheritdoc cref="object"/>
        public override bool Equals(object obj) { return (obj is LuvColor other) && Equals(other); }

        /// <inheritdoc cref="object"/>
        public override int GetHashCode()
        {
            unchecked
            {
                int hashCode = L.GetHashCode();
                hashCode = (hashCode * 397) ^ u.GetHashCode();
                hashCode = (hashCode * 397) ^ v.GetHashCode();
                return hashCode;
            }
        }


        /// <inheritdoc cref="object"/>
        public override string ToString() { return string.Format(CultureInfo.InvariantCulture, "Luv [L={0:0.##}, u={1:0.##}, v={2:0.##}]", L, u, v); }


        /// <summary>
        ///     L* (lightness)
        /// </summary>
        /// <remarks>
        ///     Ranges from 0 to 100.
        /// </remarks>
        public double L { get; }

        /// <summary>
        ///     u*
        /// </summary>
        /// <remarks>
        ///     Ranges usually from -100 to 100.
        /// </remarks>
        public double u { get; }

        /// <summary>
        ///     v*
        /// </summary>
        /// <remarks>
        ///     Ranges usually from -100 to 100.
        /// </remarks>
        public double v { get; }


        /// <summary>
        ///     <see cref="IColorVector"/>
        /// </summary>
        public Vector Vector => new[] { L, u, v };


        /// <remarks>
        ///     <see cref="Illuminants"/>
        /// </remarks>
        public XYZColor WhitePoint => _whitePoint ?? DefaultWhitePoint;

    }
}