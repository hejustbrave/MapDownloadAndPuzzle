# Tifer
这是一款基于C# .net6.0-windows的开源爬取天地图并拼接成Tif的工具

地图可视化采用GMap.net，由于爬的是天地图所以改了下源码，保证了
1.底图是天地图
2.网格文字显示利于理解

爬取代码参照https://zhuanlan.zhihu.com/p/111193164

拼接代码参照https://www.cnblogs.com/begodlike/articles/6430005.html

操作为
1.输入天地图的Token后加载影像
2.点击开始框选后在左侧点击两点绘制矩形范围。
3.点击选择输出文件夹后点击爬取开始调用爬取脚本。
4.爬取成功后点击拼接，将爬取后的文件夹调用GDAL进行拼接。
![image](https://github.com/ZhengYongHe/Tifer/assets/45898487/e9eca96f-9c3b-4b6b-9c61-d798bc0cac02)

tips:代码仅为学习代码，不对任何二开和商业行为负责。另外，爬取行为不可取。



