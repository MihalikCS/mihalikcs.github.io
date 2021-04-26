from pymongo import MongoClient
from bson.objectid import ObjectId

class DataBaseObjectLayer(object):
    """ Generic CRUD operations for MongoDB """

    def __init__(self, username, password, database, port):
        # Initializing the MongoClient. This helps to 
        # access the MongoDB databases and collections. 
        #self.client = MongoClient('mongodb://%s:%s@localhost:%s/?authMechanism=DEFAULT' % (username, password, port))
        self.client = MongoClient('mongodb://127.0.0.1:%s/' % port)
        self.database = self.client['AAC']

# Complete this create method to implement the C in CRUD.
    def create(self, data, collection):
        if data is not None:
            insertSuccess = self.database[collection].insert(data)  # data should be dictionary
            # Check insertSuccess for operation
            if insertSuccess != 0:
                return False
            # default return
            return True
        else:
            raise Exception("Nothing to save, because data parameter is empty")

# Create method to implement the R in CRUD.
    def read(self, searchData, collection):
        if searchData:
            data = self.database[collection].find(searchData, {"_id": False})
        else:
            data = self.database[collection].find( {}, {"_id": False})
        # Return the dataset else let the error flow up
        return data
    
# Create method to implement the U in CRUD.
    def update(self, searchData, updateData, collection):
        if searchData is not None:
            result = self.database[collection].update_many(searchData, { "$set": updateData })
        else:
            return "{}"
        # Return the dataset else let the error flow up
        return result.raw_result
    
# Create method to implement the D in CRUD.
    def delete(self, deleteData, collection):
        if deleteData is not None:
            result = self.database[collection].delete_many(deleteData)
        else:
            return "{}"
        # Return the dataset else let the error flow up
        return result.raw_result

# JOINS

# Create method to join tables together.
    def join(self, collection1, localField, collection2, foreignField, alias):
        result = self.database[collection1].aggregate([
                    {
                        "$lookup":
                        {
                            "from": "%s" % collection2 ,
                            "localField": "%s" % localField,
                            "foreignField": "%s" % foreignField,
                            "as": "%s" % alias
                        }
                    }
                ])
        # Return the dataset else let the error flow up
        return result

# INDEX CREATION/DELETION

# Create index
    def createIndex(self, keys, options, collection):
        if options:
            result = self.database[collection].create_index(keys, options)
        else:
            result = self.database[collection].create_index(keys)
        # Return the dataset else let the error flow up
        return result

# delete index
    def dropIndex(self, keys, collection):
        result = self.database[collection].drop_index(keys)
        # Return the dataset else let the error flow up
        return result
