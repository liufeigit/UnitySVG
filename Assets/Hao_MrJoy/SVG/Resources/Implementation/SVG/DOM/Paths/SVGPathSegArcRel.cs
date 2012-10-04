using UnityEngine;

public class SVGPathSegArcRel : SVGPathSeg, ISVGDrawableSeg {
  private float _x      = 0f;
  private float _y      = 0f;
  private float _r1      = 0f;
  private float _r2      = 0f;
  private float _angle    = 0f;
  private bool _largeArcFlag  = false;
  private bool _sweepFlag  = false;
  //================================================================================
  public float x {
    get { return this._x; }
  }
  //-----
  public float y {
    get { return this._y; }
  }
  //================================================================================
  public SVGPathSegArcRel(float r1, float r2, float angle,
              bool largeArcFlag, bool sweepFlag,
              float x, float y) : base() {
    this._r1 = r1;
    this._r2 = r2;
    this._angle = angle;
    this._largeArcFlag = largeArcFlag;
    this._sweepFlag = sweepFlag;
    this._x = x;
    this._y = y;
  }
  //================================================================================
  public override Vector2 currentPoint {
    get {
      Vector2 _return = new Vector2(0f,0f);
      SVGPathSeg _prevSeg = previousSeg;
      if(_prevSeg != null) {
        _return.x = _prevSeg.currentPoint.x + this._x;
        _return.y = _prevSeg.currentPoint.y + this._y;
      }
      return _return;
    }
  }
  //--------------------------------------------------------------------------------
  //Method: Render
  //--------------------------------------------------------------------------------
  public void Render(SVGGraphicsPath _graphicsPath) {
    Vector2 p;
    p = currentPoint;
    _graphicsPath.AddArcTo(this._r1, this._r2, this._angle,
            this._largeArcFlag, this._sweepFlag, p);
  }
}
