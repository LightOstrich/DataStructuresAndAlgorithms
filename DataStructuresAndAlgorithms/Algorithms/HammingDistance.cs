namespace DataStructuresAndAlgorithms.Algorithms;

public class HammingDistanceAlgorithm
{
    /// <summary>
    /// Compute the Hamming distance of two integers 
    /// </summary>
    /// <param name="x"></param>
    /// <param name="y"></param>
    /// <returns></returns>
    public int HammingDistance(int x, int y)
    {
        var dist = 0;
        for (var val = x ^ y; val > 0; ++dist)
        {
            val &= (val - 1);
        }

        return dist;
    }
}