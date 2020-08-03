﻿using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using Vector = System.Collections.Generic.IReadOnlyList<double>;


namespace ColorPicker.ColorModels
{
    /// <summary>
    ///     CIE xyY color space (derived from <see cref="XYZColor"/> color space)
    /// </summary>
    public readonly struct xyYColor : IColorVector
    {

        /// <param name="vector"><see cref="Vector"/>, expected 3 dimensions (usually from 0 to 1) </param>
        public xyYColor(Vector vector) : this(vector[0], vector[1], vector[2])
        {
        }

        /// <param name="chromaticity"> Chromaticity coordinates (x and y together) </param>
        /// <param name="Y"> Y (usually from 0 to 1) </param>
        public xyYColor(xyChromaticityCoordinates chromaticity, double Y)
        {
            Chromaticity = chromaticity;
            Luminance = Y;
        }

        /// <param name="x"> x (usually from 0 to 1) chromaticity coordinate </param>
        /// <param name="y"> y (usually from 0 to 1) chromaticity coordinate </param>
        /// <param name="Y"> Y (usually from 0 to 1) </param>
        public xyYColor(double x, double y, double Y) : this(new xyChromaticityCoordinates(x, y), Y)
        {
        }

        /// <inheritdoc cref="object"/>
        public static bool operator !=(xyYColor left, xyYColor right)
        {
            return !Equals(left, right);
        }

        /// <inheritdoc cref="object"/>
        public static bool operator ==(xyYColor left, xyYColor right)
        {
            return Equals(left, right);
        }


        /// <inheritdoc cref="object"/>
        [SuppressMessage("ReSharper", "CompareOfFloatsByEqualityOperator")]
        public bool Equals(xyYColor other) { return (x == other.x) && (y == other.y) && (Luminance == other.Luminance); }

        /// <inheritdoc cref="object"/>
        public override bool Equals(object obj) { return (obj is xyYColor other) && Equals(other); }

        /// <inheritdoc cref="object"/>
        public override int GetHashCode()
        {
            unchecked
            {
                int hashCode = x.GetHashCode();
                hashCode = (hashCode * 397) ^ y.GetHashCode();
                hashCode = (hashCode * 397) ^ Luminance.GetHashCode();
                return hashCode;
            }
        }


        /// <inheritdoc cref="object"/>
        public override string ToString() { return string.Format(CultureInfo.InvariantCulture, "xyY [x={0:0.##}, y={1:0.##}, Y={2:0.##}]", x, y, Luminance); }

        /// <remarks>
        ///     Chromaticity coordinates (identical to x and y)
        /// </remarks>
        public xyChromaticityCoordinates Chromaticity { get; }

        /// <summary>
        ///     Y channel (luminance)
        /// </summary>
        /// <remarks>
        ///     Ranges usually from 0 to 1.
        /// </remarks>
        public double Luminance { get; }


        /// <summary>
        ///     <see cref="IColorVector"/>
        /// </summary>
        public Vector Vector => new[] { x, y, Luminance };


        /// <remarks>
        ///     Ranges usually from 0 to 1.
        /// </remarks>
        public double x => Chromaticity.x;


        /// <remarks>
        ///     Ranges usually from 0 to 1.
        /// </remarks>
        public double y => Chromaticity.y;

    }
}