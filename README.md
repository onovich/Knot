# Knot
Knot is an intersection detection library that supports AABB, OBB, circle, and convex hull detection. <br/>
**Knot 是一个交叉检测库，支持了 AABB、OBB、圆形、凸包检测。**

The algorithms do not prioritize performance, making it suitable for use during editing rather than runtime. <br/>
**在算法上没有追求性能，适合在编辑时而非运行时使用。**

Originally developed as part of the "pathfinding trio" alongside [Toaster](https://github.com/onovich/Toaster) and [Compass](https://github.com/onovich/Compass), it was designed for polygon detection during pathfinding mesh baking. <br/>
**最初和 [Toaster](https://github.com/onovich/Toaster)、[Compass](https://github.com/onovich/Compass) 作为"寻路三件套"而开发，被设计用于烘焙寻路网格时的多边形检测。**

There was a consideration to include it as part of a physics engine, but this plan was abandoned in favor of developing Pulse as a more formal runtime physics engine. <br/>
**曾考虑作为物理引擎的一部分，但后续开发了 [Pulse](https://github.com/onovich/Pulse) 作为更正式的运行时物理引擎，所以放弃了这个计划。**

In the future, when rewriting the pathfinding solution, it may be integrated into the baking library.<br/>
**将来考虑重写寻路方案，可能会被合并进烘焙库。**
