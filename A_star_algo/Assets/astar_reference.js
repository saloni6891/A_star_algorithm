var astar = {
	init:function(map){
	for(var x = 0, x < map.length; x++){
		for(var y = 0; y < map[map.length].length; y++){
			var loc = map[x][y];
			loc.f = 0; // why?
			loc.g = 0; //why?
			loc.h = 0; //why?
			loc.cost = 1;
			loc.visited = false;
			loc.closed = false;
			loc.parent = null;
			}
		} 
	};

	heap:function heap(){
		return new BinaryHeap(function(loc)){
			return loc.f;
		});
	},

	search: function(map, start, end){
		astar.init(map);
		
		var openHeap = astar.heap();
		
		openHeap.push(start);
		
		while(openHeap.size() > 0){
			var currentNode = openHeap.pop();
			
			if(currentNode === end) {
                var curr = currentNode;
                var ret = [];
                while(curr.parent) {
                    ret.push(curr);
                    curr = curr.parent;
                }
                return ret.reverse();
            }
			
			currentNode.closed = true;
 
            // Find all neighbors for the current node. Optionally find diagonal neighbors as well (false by default).
            var neighbors = astar.neighbors(grid, currentNode);
 
            for(var i=0, i<neighbors.length; i++) {
                var neighbor = neighbors[i];
 
                //if(neighbor.closed || neighbor.isWall()) {
                    // Not a valid node to process, skip to next neighbor.
                    //continue;
                //}
				
				// The g score is the shortest distance from start to current node.
                // We need to check if the path we have arrived at this neighbor is the shortest one we have seen yet.
                var gScore = currentNode.g + neighbor.cost;
                var beenVisited = neighbor.visited;
 
                if(!beenVisited || gScore < neighbor.g) {
 
                    // Found an optimal (so far) path to this node.  Take score for node to see how good it is.
                    neighbor.visited = true;
                    neighbor.parent = currentNode;
                    neighbor.h = neighbor.h || heuristic(neighbor.pos, end.pos);
                    neighbor.g = gScore;
                    neighbor.f = neighbor.g + neighbor.h;
 
                    if (!beenVisited) {
                        // Pushing to heap will put it in proper place based on the 'f' value.
                        openHeap.push(neighbor);
                    }
                    else {
                        // Already seen the node, but since it has been rescored we need to reorder it in the heap
                        openHeap.rescoreElement(neighbor);
                    }
                }
            }
        }
 
        // No result was found - empty array signifies failure to find path.
        return [];
	},
	
	manhattan: function(pos0, pos1){
		var p1 = Math.abs(pos1.x - pos0.x);
		var p2 = Math.abs(pos1.y - pos0.y);
		return p1 + p1;
	},
	
	neighbors: function(map, loc){
		var ret = [];
		var x = loc.x;
		var y = loc.y;
		
		//North
		if(map[x] && map[x][y+1]){
			ret.push(map[x][y+1]);
		}
		
		//East
		if(map[x+1] && map[x+1][y]){
			ret.push(map[x+1][y]);
		}
		
		//West
		if(map[x-1] && map[x-1][y]){
			ret.push(map[x-1][y]);
		}
		
		//South
		if(map[x] && map[x][y-1]){
			ret.push(map[x][y-1]);
		}
		
		return ret;
	}
};