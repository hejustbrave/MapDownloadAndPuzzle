# MapDownloadAndPuzzle 
这是一款开源爬取天地图影像并拼接成Tif的工具  

框架及依赖如下，python已包括在项目内  
.net6.0-windows  
GMap.net2.1.6  
GDAL3.8.1  
Python3.11.8  

地图可视化采用GMap.net，由于爬的是天地图所以改了下源码，保证了  
1.底图是天地图  
2.网格文字显示利于理解  
  
爬取代码参照https://zhuanlan.zhihu.com/p/111193164  

拼接代码参照https://www.cnblogs.com/begodlike/articles/6430005.html  

操作为
1.输入天地图的Token后加载影像  
2.点击开始框选后在左侧点击两点绘制矩形范围。  
3.点击选择输出文件夹后点击爬取开始调用爬取脚本。  
4.爬取成功后点击拼接，将爬取后的文件夹调用GDAL进行拼接,拼接后的文件名为combine.tif，默认坐标系为wgs84。  
![image](https://github.com/ZhengYongHe/Tifer/assets/45898487/e9eca96f-9c3b-4b6b-9c61-d798bc0cac02)
![image](https://github.com/ZhengYongHe/Tifer/assets/45898487/9e473474-3036-4f22-be1f-73f3be048cc3)
![image](https://github.com/ZhengYongHe/Tifer/assets/45898487/0aef424e-5b1b-4318-8736-7888449d191e)



tips:  
1.声明：本软件仅供个人学习与科研使用，所下载的数据版权归各个地图服务商所有，任何组织或个人因数据使用不当造成的问题，软件作者不负责任。      
2.框选的范围不等于最终拼接结果，因为拼接是基于爬取的瓦片，瓦片是基于框选范围所包括的所有瓦片。



